using System;
using System.Linq;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Movie_Base.ViewModel
{
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class MovieItemCommom : Bindable
    {
        private static readonly Uri _baseUri = new Uri("ms-appx:///");

        protected MovieItemCommom(string uniqueId, string title, string rating, string audienceScore, string criticsScore, string clips, string reviews, string cast, string imagePath, String description)
        {
            this._uniqueId = uniqueId;
            this._title = title;
            this._rating = rating;
            this._audienceScore = audienceScore;
            this._criticsScore = criticsScore;
            this._clips = clips;
            this._reviews = reviews;
            this._cast = cast;
            this._description = description;
            this._imagePath = imagePath;
        }

        private string _uniqueId = string.Empty;
        public string UniqueId
        {
            get { return this._uniqueId; }
            set { this.SetProperty(ref this._uniqueId, value); }
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        private string _rating;

        public string Rating
        {
            get { return _rating; }
            set { this.SetProperty(ref this._rating, value); }
        }

        private string _audienceScore;
        public string AudienceScore
        {
            get { return _audienceScore; }
            set { this.SetProperty(ref this._audienceScore, value); }
        }

        private string _criticsScore;
        public string CriticsScore
        {
            get { return _criticsScore; }
            set { this.SetProperty(ref this._criticsScore, value); }
        }

        private string _clips;
        public string Clips
        {
            get { return _clips; }
            set { this.SetProperty(ref this._clips, value); }
        }

        private string _reviews;
        public string Reviews
        {
            get { return _reviews; }
            set { this.SetProperty(ref this._reviews, value); }
        }

        private string _cast;
        public string Cast
        {
            get { return _cast; }
            set { this.SetProperty(ref this._cast, value); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }

        private ImageSource _image = null;
        private string _imagePath = null;
        public ImageSource Image
        {
            get
            {
                if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(MovieItemCommom._baseUri, this._imagePath));
                }
                return this._image;
            }

            set
            {
                this._imagePath = null;
                this.SetProperty(ref this._image, value);
            }
        }

        public void SetImage(string path)
        {
            this._image = null;
            this._imagePath = path;
            this.OnPropertyChanged("Image");
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}