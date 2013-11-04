using System;
using System.Linq;

namespace Movie_Base.ViewModel
{
    [Windows.Foundation.Metadata.WebHostHidden]
    public class MovieReviewItem : Bindable
    {
        public MovieReviewItem(
            string critic,
            string date,
            string freshness,
            string publication,
            string quote,
            string link)
        {
            this._critic = critic;
            this._date = date;
            this._freshness = freshness;
            this._publication = publication;
            this._quote = quote;
            this._link = link;
        }

        private string _critic = string.Empty;
        public string Critic
        {
            get { return this._critic; }
            set { this.SetProperty(ref this._critic, value); }
        }

        private string _date = string.Empty;
        public string Date
        {
            get { return this._date; }
            set { this.SetProperty(ref this._date, value); }
        }

        private string _freshness = string.Empty;
        public string Freshness
        {
            get { return this._freshness; }
            set { this.SetProperty(ref this._freshness, value); }
        }

        private string _publication = string.Empty;
        public string Publication
        {
            get { return this._publication; }
            set { this.SetProperty(ref this._publication, value); }
        }

        private string _quote = string.Empty;
        public string Quote
        {
            get { return this._quote; }
            set { this.SetProperty(ref this._quote, value); }
        }

        private string _link = string.Empty;
        public string Link
        {
            get { return this._link; }
            set { this.SetProperty(ref this._link, value); }
        }
    }
}