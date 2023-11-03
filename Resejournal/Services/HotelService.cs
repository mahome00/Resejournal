using Newtonsoft.Json;
using Resejournal.Data;
using System.Diagnostics;

namespace Resejournal.Services
{
    public class HotelService
    {


        public async Task<int?> GetGeoIdByCityName(string cityName)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://tripadvisor16.p.rapidapi.com/api/v1/hotels/searchLocation?query={cityName}"),
            };

            request.Headers.Add("X-RapidAPI-Key", "6fff01a254msh4a6fce0e35f147cp1c6406jsnbf00cb28f263");
            request.Headers.Add("X-RapidAPI-Host", "tripadvisor16.p.rapidapi.com");
            try
            {
                using (var response = await client.SendAsync(request))
                {
                    Debug.WriteLine($"HTTP Response Status Code: {response.StatusCode}");
                    response.EnsureSuccessStatusCode();
                    var responseBody = JsonConvert.DeserializeObject<LocationApiResponse>(await response.Content.ReadAsStringAsync());

                    if (responseBody?.Data != null && responseBody.Data.Count > 0)
                    {
                        return responseBody.Data[0].GeoId;
                    }
                }
            }
            catch (HttpRequestException e)
            {

                Debug.WriteLine($"Request error: {e.Message}");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error: {e.Message}");
            }

            return null; // Inget geoId hittades
        }

        public async Task<List<HotelData>> GetHotelsByGeoIdAndDates(int geoId, DateTime checkIn, DateTime checkOut)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://tripadvisor16.p.rapidapi.com/api/v1/hotels/searchHotels?geoId={geoId}&checkIn={checkIn:yyyy-MM-dd}&checkOut={checkOut:yyyy-MM-dd}&pageNumber=1&currencyCode=USD"),
            };

            request.Headers.Add("X-RapidAPI-Key", "6fff01a254msh4a6fce0e35f147cp1c6406jsnbf00cb28f263");
            request.Headers.Add("X-RapidAPI-Host", "tripadvisor16.p.rapidapi.com");

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var responseBody = JsonConvert.DeserializeObject<ApiResponse>(await response.Content.ReadAsStringAsync());

                return responseBody?.Data?.Data ?? new List<HotelData>();
            }
        }

    }
}
