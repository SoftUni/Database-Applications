import java.util.List;

import org.hibernate.Session;
import org.hibernate.SessionFactory;

import data.HibernateUtil;
import domain.Employee;

public class MainClass {
	public static void main(String[] args) {
        // Read
        System.out.println("******* READ *******");
        List employees = list();
        System.out.println("Total Employees: " + employees.size());
         
        // Write
        System.out.println("******* WRITE *******");
        Employee empl = new Employee("Jack", "Bauer", new java.util.Date(System.currentTimeMillis()), "911");
        empl = save(empl);
        empl = read(empl.getId());
        System.out.printf("%d %s %s \n", empl.getId(), empl.getFirstname(), empl.getLastname());
         
         
        // Update
        System.out.println("******* UPDATE *******");
        Employee empl2 = read(1l); // read employee with id 1
        System.out.println("Name Before Update:" + empl2.getFirstname());
        empl2.setFirstname("James");
        update(empl2);  // save the updated employee details
         
        empl2 = read(1l); // read again employee with id 1
        System.out.println("Name Aftere Update:" + empl2.getFirstname());
         
        // Delete
        System.out.println("******* DELETE *******");
        //delete(empl); 
        Employee empl3 = read(empl.getId());
        System.out.println("Object:" + empl3);
	}
	
	private static Employee save(Employee employee) {
	    SessionFactory sf = HibernateUtil.getSessionFactory();
	    Session session = sf.openSession();
	    session.beginTransaction();
	 
	    Long id = (Long) session.save(employee);
	    employee.setId(id);
	         
	    session.getTransaction().commit();
	         
	    session.close();
	 
	    return employee;
	}
	
	private static List list() {
	    SessionFactory sf = HibernateUtil.getSessionFactory();
	    Session session = sf.openSession();
	 
	    List employees = session.createQuery("from Employee").list();
	    session.close();
	    return employees;
	}
	private static Employee read(Long id) {
	    SessionFactory sf = HibernateUtil.getSessionFactory();
	    Session session = sf.openSession();
	 
	    Employee employee = (Employee) session.get(Employee.class, id);
	    session.close();
	    return employee;
	}
	
	private static Employee update(Employee employee) {
	    SessionFactory sf = HibernateUtil.getSessionFactory();
	    Session session = sf.openSession();
	 
	    session.beginTransaction();
	 
	    session.merge(employee);
	 
	    session.getTransaction().commit();
	 
	    session.close();
	    return employee;
	 
	}
	
	private static void delete(Employee employee) {
	    SessionFactory sf = HibernateUtil.getSessionFactory();
	    Session session = sf.openSession();
	 
	    session.beginTransaction();
	 
	    session.delete(employee);
	 
	    session.getTransaction().commit();
	 
	    session.close();
	}

}
