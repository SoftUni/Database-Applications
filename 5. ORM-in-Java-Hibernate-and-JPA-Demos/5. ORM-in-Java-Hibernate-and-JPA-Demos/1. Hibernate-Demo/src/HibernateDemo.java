import java.util.List;
import java.util.Set;
import java.util.stream.Collectors;

import model.Course;
import model.Department;
import model.Person;
import model.Student;

import org.hibernate.Criteria;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;
import org.hibernate.cfg.Configuration;
import org.hibernate.service.ServiceRegistry;

public class HibernateDemo {

	public static void main(String[] args) {
		SessionFactory sessionFactory = createSessionFactory();
		Session session = sessionFactory.openSession();
		try {
			listDepartments(session);
			createDepartment(session);
			listStudents(session);
			createStudent(session);
			editStudent(session);			
		} finally {
			session.close();
		}
	}
	
	public static SessionFactory createSessionFactory() {
		Configuration cfg = new Configuration();
		cfg.configure();
		ServiceRegistry serviceRegistry = 
				new StandardServiceRegistryBuilder().applySettings(
		        cfg.getProperties()).build();
		SessionFactory factory = cfg.buildSessionFactory(serviceRegistry);
        return factory;
    }

	@SuppressWarnings("unchecked")
	private static void listDepartments(Session session) {
		System.out.println("Departments:");
		Criteria allStudentsCriteria = session.createCriteria(Department.class);
		List<Department> allDepartments = allStudentsCriteria.list();
		for (Department dept : allDepartments) {
			System.out.printf(" - Id=%d, Name=%s\n", 
					dept.getDeptId(), dept.getName());
		}
	}
	
	private static void createDepartment(Session session) {
		try {
			session.beginTransaction();
			System.out.println("-- Starting new transaction.");
			
			Department dept = new Department();
			dept.setName("New Department");
			session.save(dept);
			System.out.println("Department inserted: " + dept.getDeptId());
			
			session.getTransaction().commit();
			System.out.println("-- Transaction committed.");
		} catch (RuntimeException e) {
			System.out.println("-- Transaction failed.");
			session.getTransaction().rollback();
			throw e;
		}
	}

	@SuppressWarnings("unchecked")
	private static void listStudents(Session session) {
		System.out.println("Students with courses:");
		Query studentsQuery = session.createQuery(
				"from Student s where facultyNumber LIKE :fn");
		studentsQuery.setParameter("fn", "%12%");
		List<Student> students = studentsQuery.list();
		for (Student stud : students) {
			Set<Course> courses = stud.getCourses();
			String coursesStr =	courses.stream().map(c -> c.getName())
					.collect(Collectors.joining("; "));
			System.out.printf(" - Id=%d, FirstName=%s, LastName=%s, FN=%s\n" +
					"   Courses: %s\n", stud.getPersonId(), stud
					.getFirstName(), stud.getLastName(), stud
					.getFacultyNumber(), coursesStr);
		}
	}
	
	private static void createStudent(Session session) {
		try {
			session.beginTransaction();
			System.out.println("-- Starting new transaction.");
			
			Student student = new Student();
			student.setFirstName("Ivan");
			student.setLastName("Ivanov");
			student.setFacultyNumber("123");
			session.save(student);
			System.out.println("Student inserted.");
			
			session.getTransaction().commit();
			System.out.println("-- Transaction committed.");
		} catch (RuntimeException e) {
			System.out.println("-- Transaction failed.");
			session.getTransaction().rollback();
			throw e;
		}
	}

	private static void editStudent(Session session) {
		try {
			session.beginTransaction();
			System.out.println("-- Starting new transaction.");
			
			Student student = (Student) session.get(Student.class, 17L);
			student.setFirstName(student.getFirstName() + "2");
			session.save(student);
			System.out.println("Student edited.");
			
			session.getTransaction().commit();
			System.out.println("-- Transaction committed.");
		} catch (RuntimeException e) {
			System.out.println("-- Transaction failed.");
			session.getTransaction().rollback();
			throw e;
		}
	}
}
