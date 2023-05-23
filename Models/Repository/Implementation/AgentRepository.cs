using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstateMvcApp.Data;
using RealEstateMvcApp.Models.Entities;
using RealEstateMvcApp.Models.Repository.Interfaces;

namespace RealEstateMvcApp.Models.Repository.Implementation
{
    public class AgentRepository : BaseRepository<Agent>, IAgentRepository
    {
        public AgentRepository(Context context)
        {
            _context = context;
        }
        public Agent Get(string id)
        {
            
            var agent = _context.AgentList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.User)
            .Include(c => c.PropertyAgents)
            .SingleOrDefault(c =>c.Id == id);
            return agent;
        }

        public Agent Get(Expression<Func<Agent, bool>> expression)
        {
             var agent = _context.AgentList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.User)
            .Include(c => c.PropertyAgents)
            .SingleOrDefault(expression);
            return agent;
        }

        public IEnumerable<Agent> GetAll()
        {
            return _context.AgentList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.User)
            .Include(c => c.PropertyAgents)
            .ToList();
        }

        public IEnumerable<Agent> GetSelected(List<string> ids)
        {
            return _context.AgentList
            .Include(c => c.User)
            .Include(c => c.PropertyAgents)
            .Where(c => c.IsDeleted == false)
            .ToList();
        }

        public IEnumerable<Agent> GetSelected(Expression<Func<Agent, bool>> expression)
        {
            return _context.AgentList
            .Include(c => c.User)
            .Include(c => c.PropertyAgents)
            .Where(expression).ToList();
        }
    }
}