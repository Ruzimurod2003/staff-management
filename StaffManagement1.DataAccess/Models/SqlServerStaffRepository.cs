using StaffManagement1.Models;

namespace StaffManagement1.DataAccess.Models;

public class SqlServerStaffRepository : IStaffRepository
{
    private readonly AppDBContext dBContext;

    public SqlServerStaffRepository(AppDBContext dBContext)
    {
        this.dBContext = dBContext;
    }
    public Staff? Delete(int id)
    {
        var staff = dBContext.Staffs.Find(id);
        if (staff != null)
        {
            dBContext.Staffs.Remove(staff);
            dBContext.SaveChanges();
        }
        return staff;
    }

    public Staff Update(Staff newStaff)
    {
        var staff = dBContext.Staffs.Attach(newStaff);
        staff.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        dBContext.SaveChanges();
        return newStaff;
    }

    Staff IStaffRepository.Create(Staff newStaff)
    {
        dBContext.Add(newStaff);
        dBContext.SaveChanges();
        return newStaff;
    }

    Staff? IStaffRepository.Get(int id)
    {
        return dBContext.Staffs.Find(id);

    }

    IEnumerable<Staff> IStaffRepository.GetAll()
    {
        return dBContext.Staffs;
    }
}

