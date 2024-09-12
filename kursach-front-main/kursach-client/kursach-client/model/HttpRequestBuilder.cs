﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace kursach_client.model
{
    public class HttpRequestBuilder
    {
        private readonly HttpClient _httpClient;
        private readonly string _token;

        public HttpRequestBuilder()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Properties.Settings.Default.ServerURL);
            _token = Properties.Settings.Default.Token;
        }

        public async Task<HttpResponseMessage> SendGetRequestAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Отправляем запрос и возвращаем ответ
            return await _httpClient.SendAsync(request);
        }

        public async Task<HttpResponseMessage> SendPostRequestAsync(string url, HttpContent content)
        {
            // Создаем POST-запрос
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };
            // Добавляем заголовок Authorization с токеном
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Отправляем запрос и возвращаем ответ
            return await _httpClient.SendAsync(request);
        }

        public async Task<HttpResponseMessage> SendPutRequestAsync(string url, HttpContent content)
        {
            // Создаем PUT-запрос
            var request = new HttpRequestMessage(HttpMethod.Put, url)
            {
                Content = content
            };
            // Добавляем заголовок Authorization с токеном
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Отправляем запрос и возвращаем ответ
            return await _httpClient.SendAsync(request);
        }

        public async Task<HttpResponseMessage> SendDeleteRequestAsync(string url)
        {
            // Создаем DELETE-запрос
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            // Добавляем заголовок Authorization с токеном
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Отправляем запрос и возвращаем ответ
            return await _httpClient.SendAsync(request);
        }
    }
}
