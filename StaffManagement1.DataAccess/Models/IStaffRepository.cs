namespace StaffManagement1.Models;

public interface IStaffRepository
{
    Staff Get(int id);

    IEnumerable<Staff> GetAll();

    Staff Create(Staff newStaff);

    Staff Update(Staff newStaff);

    Staff Delete(int id);

}

