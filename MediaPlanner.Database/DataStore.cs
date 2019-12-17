using MediaPlanner.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlanner.Database
{
    public class DataStore
    {
        private static Dictionary<string, object> _cachedData = null;
        private static readonly MediaPlannerDBContext _context = null;

        static DataStore()
        {
            _context = _context ?? new MediaPlannerDBContext();
            _cachedData = _cachedData ?? new Dictionary<string, object>();
        }

        public object GetMasterDataByKey(string key)
        {
            try
            {
                if (!isSet(key))
                {
                    switch (key)
                    {
                        case "CLIENT":
                            _cachedData.Add(key, _context.Client.ToList());
                            break;
                        case "SUPPLIER":
                            _cachedData.Add(key, _context.Supplier.ToList());
                            break;
                        case "COUNTRY":
                            _cachedData.Add(key, _context.Country.ToList());
                            break;
                        case "CHANNEL":
                            _cachedData.Add(key, _context.Channel.ToList());
                            break;
                    }
                }

                return _cachedData[key];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void resetKey(string key)
        {
            if (_cachedData != null && _cachedData.ContainsKey(key))
                _cachedData.Remove(key);
        }

        private bool isSet(string key) => _cachedData != null && _cachedData.ContainsKey(key);

        public async Task<bool> Save(Campaign campaign)
        {
            try
            {
                if (campaign != null && !string.IsNullOrWhiteSpace(campaign.Title))
                {
                    await _context.Campaign.AddAsync(campaign);
                    await _context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Campaign> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Campaign.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Campaign>> GetAllAsync()
        {
            try
            {
                return await _context.Campaign.Include(x => x.CampaignDetail).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
