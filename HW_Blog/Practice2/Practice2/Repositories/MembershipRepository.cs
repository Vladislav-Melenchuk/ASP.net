using Microsoft.EntityFrameworkCore;
using Practice2.Data;
using Practice2.Interfaces;
using Practice2.Models;

namespace Practice2.Repositories
{
    public class MembershipRepository : IMembership
    {
        private readonly ApplicationContext _applicationContext;
        public MembershipRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        //public async Task AddMembershipAsync(Membership membership)
        //{
        //    membership.CreatedDate = DateTime.UtcNow;
        //    await _applicationContext.Memberships.AddAsync(membership);
        //    await _applicationContext.SaveChangesAsync();
        //}

        //public async Task DeleteMembershipAsync(Membership membership)
        //{
        //    _applicationContext.Memberships.Remove(membership);
        //    await _applicationContext.SaveChangesAsync();
        //}

        //public async Task DisableMembershipCodeAsync(string code)
        //{
        //    var membership = await _applicationContext.Memberships.FirstOrDefaultAsync(m => m.Code == code);

        //    if (membership != null)
        //    {
        //        membership.IsEnable = false;
        //        await _applicationContext.SaveChangesAsync();
        //    }
        //}

        //public async Task<bool> EnableCodeMembershipByCodeAsync(string code)
        //{
        //    var membership = await _applicationContext.Memberships.FirstOrDefaultAsync(m => m.Code == code);

        //    if (membership == null)
        //        return false;

        //    membership.IsEnable = true;
        //    await _applicationContext.SaveChangesAsync();

        //    return true;
        //}

        //public async Task<bool> ExistsMembershipByCodeAsync(string code)
        //{
        //    return await _applicationContext.Memberships.AnyAsync(m => m.Code == code);
        //}

        //public async Task<IEnumerable<Membership>> GetAllMembershipsAsync()
        //{
        //    return await _applicationContext.Memberships.ToListAsync();
        //}

        //public async Task<Membership> GetMembershipAsync(int id)
        //{
        //    return await _applicationContext.Memberships.FindAsync(id);
        //}

        public async Task<IEnumerable<Membership>> GetAllMembershipsAsync()
        {
            return await _applicationContext.Memberships.OrderByDescending(e => e.Id).ToListAsync();
        }

        public async Task<Membership> GetMembershipAsync(int id)
        {
            return await _applicationContext.Memberships.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddMembershipAsync(Membership membership)
        {
            _applicationContext.Memberships.Add(membership);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteMembershipAsync(Membership membership)
        {
            _applicationContext.Memberships.Remove(membership);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsMembershipByCodeAsync(string code)
        {
            return await _applicationContext.Memberships.AnyAsync(e => e.Code.Equals(code));
        }

        public async Task DisableMembershipCodeAsync(string code)
        {
            var currentMemberShip = await _applicationContext.Memberships.FirstOrDefaultAsync(e => e.Code.Equals(code));
            if (currentMemberShip != null)
            {
                currentMemberShip.IsEnable = false;
                await _applicationContext.SaveChangesAsync();
            }
        }

        public async Task<bool> EnableCodeMembershipByCodeAsync(string code)
        {
            var currentMemberShip = await _applicationContext.Memberships.FirstOrDefaultAsync(e => e.Code.Equals(code));
            if (currentMemberShip != null)
            {
                return currentMemberShip.IsEnable;
            }
            return false;
        }
    }
}
