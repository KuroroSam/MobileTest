using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace Core
{
	public class Domain
	{
		public Domain ()
		{
		}

		public async Task<List<Meal>> GetItems()
		{
            var url1 = @"http://cdn1.hk.opensnap.com/azsg/snapphoto/photo/LL/H2BK/3DCI9C6E13F4071554A5AAn.jpg";
            var url2 = @"http://static1.orstatic.com/userphoto/photo/C/A10/01ZB5B0A468C6A48CDBCC9n.jpg";
            var url3 = @"http://static1.orstatic.com/userphoto/photo/C/A10/01ZB50C3343DF8EBBB7275n.jpg";

            var image1 = await GetImageSource(url1);
            var image2 = await GetImageSource(url2);
            var image3 = await GetImageSource(url3);

            var items = new List<Meal> { 
                new Meal{ Title = "Crab", Location = "On-Yasai", ImageSource = image1},
                new Meal{ Title = "Egg", Location = "On-Yasai", ImageSource = image2},
                new Meal{ Title = "Beef", Location = "On-Yasai", ImageSource = image3},
            };

            return items;
		}

		public async Task<Meal> UpdateItem(Meal item)
		{
            //Simulate the random response time from server
            Random rnd = new Random();
            var timeout = rnd.Next(3000,10000);
            System.Diagnostics.Debug.WriteLine(timeout);

            await Task.Delay(timeout);
            
            
            return item;
		}

        
        public async Task<byte[]> GetImageSource(String imageURL)
        {
			var client = new HttpClient();

            byte[] imageBytes = await client.GetByteArrayAsync(imageURL);

            return imageBytes;
        }
	}
}

