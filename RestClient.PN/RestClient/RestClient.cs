using Model.PN.Model;
using Newtonsoft.Json;
using RestClient.PN.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.PN.RestClient
{
    public class RestClient<T>
    {
        protected HttpClient client = new HttpClient();
        public IList<T> DataSource { get; set; }

        private string endpoint;
        public bool reloading { get; set; } = false;

        public event EventHandler? DataChangedHandler;
        public RestClient(string inEndpoint)
        {
            this.endpoint = inEndpoint;
            Initialize();
        }

        public RestClient()
        {
            Initialize();
        }

        private void Initialize()
        {
            DataSource = new List<T>();
            client.BaseAddress = new Uri(DataService.baseUrl);
        }

        public List<T> getDataSource()
        {
            return (List<T>)DataSource;
        }
        public void loadAll()
        {
            Task<HttpResponseMessage> responseTask = client.GetAsync(endpoint);

            responseTask.Wait();

            if (responseTask.Result.IsSuccessStatusCode)
            {
                Task<string> responseContent = responseTask.Result.Content.ReadAsStringAsync();

                DataSource = JsonConvert.DeserializeObject<IList<T>>(responseContent.Result);
            }
        }

        public void deleteRow(int id)
        {
            Task<HttpResponseMessage> responseTask;

            if (DataSource != null)
            {
                responseTask = client.DeleteAsync(endpoint + "/" + id);

                responseTask.Wait();

                if (responseTask.Result.IsSuccessStatusCode)
                {
                    DataChangedHandler?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public void updateRow(int index)
        {

            T dataItem;

            string requestBody;

            StringContent content;

            Task<HttpResponseMessage> responseTask;

            if (DataSource != null)
            {
               
                requestBody = JsonConvert.SerializeObject(DataSource[index]);

                content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                responseTask = client.PostAsync(endpoint, content);

                responseTask.Wait();

                if (responseTask.Result.IsSuccessStatusCode)
                {
                    Task<string> responseContent = responseTask.Result.Content.ReadAsStringAsync();

                    responseTask.Wait();

                    if (responseContent != null)
                    {
                        IList<T>? responseBundle = JsonConvert.DeserializeObject<IList<T>>(responseContent.Result);
                        if (DataSource[index] != null
                                && responseBundle != null
                                    && responseBundle.Count > 0)
                        {
                            if ((DataSource[index] as BaseEntity).Id == 0)
                                (DataSource[index] as BaseEntity).Id = (responseBundle.ToList()[0] as BaseEntity).Id;
                            else
                                DataSource[index] = responseBundle.ToList()[0];

                            DataChangedHandler?.Invoke(this, EventArgs.Empty);
                        }
                    }
                }
            }
        }
    }
}
