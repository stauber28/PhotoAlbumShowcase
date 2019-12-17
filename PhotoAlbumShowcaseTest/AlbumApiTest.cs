using NUnit.Framework;
using PhotoAlbumShowcase;
using System.Threading.Tasks;

namespace PhotoAlbumShowcaseTest
{
    [TestFixture]
    public class AlbumApiTest
    {
        private AlbumApi _albumApi;

        [SetUp]
        public void Setup()
        {
            _albumApi = new AlbumApi();
        }

        [Test]
        public async Task GetPhotosTest_PhotoAlbumIdMatch([Random(-100, 1000, 100)]int albumId)
        {
            var photos = await _albumApi.GetPhotos(albumId);

            foreach (var photo in photos)
            {
                Assert.AreEqual(albumId, photo.AlbumId);
            }
        }
    }
}