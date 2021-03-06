// ------------------------------------------------------------------------
// ========================================================================
// THIS CODE AND INFORMATION ARE GENERATED BY AUTOMATIC CODE GENERATOR
// ========================================================================
// Template:   	DataSource.tt
// Version:		2.0
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Entities=WPAppStudio.Entities;
using IServices=WPAppStudio.Services.Interfaces;
using RepositoriesBase=WPAppStudio.Repositories.Base;
using WPAppStudio.Shared;

namespace WPAppStudio.Repositories
{
    /// <summary>
    /// SponsorsDSSchema data source.
    /// </summary>
    [CompilerGenerated]
    [GeneratedCode("Radarc", "4.0")]
    public class Sponsors_SponsorsDS : ISponsors_SponsorsDS 
    {
		private static bool _alreadyAccessed;
		private const int MaxResults = 10;
		private readonly RepositoriesBase.IJsonDataSource _jsonDataSource; 
		private readonly IServices.IStorageService _storageService;
        private readonly IServices.IInternetService _internetService;
		private const string DataServiceUrl = "http://apps.windowsstore.com/api/data?clientId={0}&appId={1}&datasourceName={2}&pageIndex={3}&blockSize={4}";

        /// <summary>
        /// Initializes a new instance of the <see cref="Sponsors_SponsorsDS" /> class.
        /// </summary>
        /// <param name="jsonDataSource">A JSON based data source.</param>
		/// <param name="internetService">A internet service</param>
        /// <param name="storageService">A storage service</param>
        public Sponsors_SponsorsDS(RepositoriesBase.IJsonDataSource jsonDataSource, IServices.IInternetService internetService, IServices.IStorageService storageService)
        {
            _jsonDataSource = jsonDataSource;
			_storageService = storageService;
            _internetService = internetService;
        }
		
        /// <summary>
        /// Retrieves the data from a dynamic data service (URL specified in DataServiceUrl) , in an observable collection of SponsorsDSSchema items.
        /// </summary>
        /// <returns>An observable collection of SponsorsDSSchema items.</returns>
        public async Task<ObservableCollection<Entities.SponsorsDSSchema>> GetData(int numPage)
        {
			if (_alreadyAccessed)
                return await LoadData(numPage);
            
            _alreadyAccessed = true;
				return await Refresh();
			}
			
        /// <summary>
        /// Retrieves the data from a dynamic data service (URL specified in DataServiceUrl), filtered by a filter specification, in an observable collection of SponsorsDSSchema items.
        /// </summary>
        /// <param name="filter">Filter operation specification</param>
        /// <returns>An observable collection of SponsorsDSSchema items.</returns>
        public async Task<ObservableCollection<Entities.SponsorsDSSchema>> Search(FilterSpecification filter)
        {
			var data = _storageService.Load<Entities.SponsorsDSSchema[]>("Sponsors_SponsorsDS");
			var searchResults = RepositoriesBase.Filter<Entities.SponsorsDSSchema>.FilterCollection(filter, data);
			if(searchResults == null || !searchResults.Any())
			{
				data = await _jsonDataSource.LoadRemote<Entities.SponsorsDSSchema[]>(string.Format(DataServiceUrl, "18273","d76d7a81-f25e-4a84-8d6d-fc87c7f08871", "SponsorsDS", 0, int.MaxValue));
				searchResults = RepositoriesBase.Filter<Entities.SponsorsDSSchema>.FilterCollection(filter, data);
			}
            return searchResults;
        }
		
        /// <summary>
        /// Retrieves the data from a dynamic data service (URL specified in DataServiceUrl) , in an observable collection of SponsorsDSSchema items.
        /// </summary>
        /// <returns>An observable collection of SponsorsDSSchema items.</returns>
        public async Task<ObservableCollection<Entities.SponsorsDSSchema>> Refresh()
        {	
			return await LoadData(0, true);
        }
		
		/// <summary>
        /// Checks if data source has a element before the passed as parameter
        /// </summary>
		/// <param name="current">Current element</param>
        /// <returns>True, if there is a previous element, false if there is not</returns>
		public bool HasPrevious(Entities.SponsorsDSSchema current)
        {
			var data = new List<Entities.SponsorsDSSchema>(_storageService.Load<Entities.SponsorsDSSchema[]>("Sponsors_SponsorsDS"));

            data = data.OrderBy(i => i.Title).ToList();
			
            if (current == null || !data.Any()) 
				return false;

            return data.IndexOf(current) > 0;
        }
		
		/// <summary>
        /// Checks if data source has a element after the passed as parameter
        /// </summary>
		/// <param name="current">Current element</param>
        /// <returns>True, if there is a next element, false if there is not</returns>
		public async Task<bool> HasNext(Entities.SponsorsDSSchema current)
        {
			var data = new List<Entities.SponsorsDSSchema>(_storageService.Load<Entities.SponsorsDSSchema[]>("Sponsors_SponsorsDS"));

            data = data.OrderBy(i => i.Title).ToList();
			
            if (current == null || !data.Any()) 
				return false;

            if(data.IndexOf(current) < data.Count - 1) 
				return true;
			
			var numPage = (int)Math.Ceiling(data.Count / (double)MaxResults);
            var nextPageData = await GetData(numPage);

		    return nextPageData.Any();
        }
		
		/// <summary>
        /// Retrieves the previous element from source.
        /// </summary>
		/// <param name="current">Current element</param>
        /// <returns>The previous element from items, if it exists. Otherwise, returns null</returns>
        public Entities.SponsorsDSSchema Previous(Entities.SponsorsDSSchema current)
        {
			var data = new List<Entities.SponsorsDSSchema>(_storageService.Load<Entities.SponsorsDSSchema[]>("Sponsors_SponsorsDS"));

            data = data.OrderBy(i => i.Title).ToList();
		
            if (current == null || !data.Any()) 
				return null;

            var index = data.IndexOf(current);

            if (index == 0 || index == -1) 
				return null;

            return data[index - 1];
        }
		
		/// <summary>
        /// Retrieves the next element from source.
        /// </summary>
		/// <param name="current">Current element</param>
        /// <returns>The next element from items, if it exists. Otherwise, returns null</returns>
        public async Task<Entities.SponsorsDSSchema> Next(Entities.SponsorsDSSchema current)
        {
			var data = new List<Entities.SponsorsDSSchema>(_storageService.Load<Entities.SponsorsDSSchema[]>("Sponsors_SponsorsDS"));

            data = data.OrderBy(i => i.Title).ToList();
			
            if (current == null || !data.Any()) 
				return null;

		    var index = data.IndexOf(current);
			
			if (index == -1) 
				return null;

		    if (index != data.Count - 1) 
				return data[index + 1];

		    var numPage = (int)Math.Ceiling(data.Count / (double)MaxResults);
            var nextPageData = await GetData(numPage);

		    if (!nextPageData.Any()) return null;

		    return nextPageData.First();
        } 
		 
        private async Task<ObservableCollection<Entities.SponsorsDSSchema>> LoadData(int pageNumber, bool forceRecaching = false)
        {
			var storedItems = _storageService.Load<Entities.SponsorsDSSchema[]>("Sponsors_SponsorsDS");
			var storedCollection = storedItems != null ? storedItems.ToList() : new List<Entities.SponsorsDSSchema>();
			
            var pageNotSaved = Math.Ceiling(storedCollection.Count() / (double)MaxResults) - 1 < pageNumber;
			
            if (_internetService.IsNetworkAvailable() && (pageNotSaved || forceRecaching))
            {
				var newItems = await _jsonDataSource.LoadRemote<Entities.SponsorsDSSchema[]>(string.Format(DataServiceUrl, "18273","d76d7a81-f25e-4a84-8d6d-fc87c7f08871", "SponsorsDS", pageNumber, MaxResults));

                if (forceRecaching)
                    storedCollection = new List<Entities.SponsorsDSSchema>();

                if(newItems != null && newItems.Any())
				{
					storedCollection.AddRange(newItems);
					_storageService.Save("Sponsors_SponsorsDS", storedCollection.ToArray());
				}
			}
				
            return new ObservableCollection<Entities.SponsorsDSSchema>(storedCollection.Skip(pageNumber * MaxResults).Take(MaxResults));
        }
	}	
}

