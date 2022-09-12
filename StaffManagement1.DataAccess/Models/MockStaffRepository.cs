namespace StaffManagement1.Models;

public class MockStaffRepository : IStaffRepository
{
    private List<Staff> _staffs = null;

    public MockStaffRepository()
    {
        _staffs = new List<Staff>()
        {
            new Staff() {Id = 1,FirstName="Ro'zimurod",LastName="Abdunazarov",Email="Ruzimurodabdunazarov@mail.ru",Department=Departments.Administrator },
            new Staff() {Id = 2,FirstName="Bob",LastName="Struard",Email="Bob_tristand@mail.ru",Department=Departments.Production },
            new Staff() {Id = 3,FirstName="Shoxob",LastName="Choriyev",Email="Choriyev2006@mail.ru",Department=Departments.RnD },
            new Staff() {Id = 4,FirstName="Nigina",LastName="Shomurodova",Email="Niginochka@mail.ru",Department=Departments.Operator }
        };
    }

    public Staff Create(Staff staff)
    {
        staff.Id = _staffs.Max(a => a.Id) + 1;
        _staffs.Add(staff);
        return staff;
    }
    public Staff Update(Staff newStaff)
    {
        var staff = _staffs.FirstOrDefault(s => s.Id == newStaff.Id);
        if (staff != null)
        {
            staff.FirstName = newStaff.FirstName;
            staff.LastName = newStaff.LastName;
            staff.Email = newStaff.Email;
            staff.Department = newStaff.Department;
        }
        return staff;
    }

    public Staff Delete(int id)
    {
        var staff = _staffs.FirstOrDefault(s => s.Id == id);
        if (staff != null)
        {
            _staffs.Remove(staff);
        }
        return staff;
    }

    public Staff Get(int id)
    {
        return _staffs.FirstOrDefault(staff => staff.Id == id);
    }

    public IEnumerable<Staff> GetAll()
    {
        return _staffs;
    }


}

