package model;

import java.util.HashSet;
import java.util.Set;

public class Professor extends Person {
	private String title;
	private Set<Department> departments = new HashSet<Department>();
	private Set<Course> courses = new HashSet<Course>();

	public Set<Course> getCourses() {
		return courses;
	}
	
	public void setCourses(Set<Course> courses) {
		this.courses = courses;
	}
	
	public Set<Department> getDepartments() {
		return departments;
	}
	
	public void setDepartments(Set<Department> departments) {
		this.departments = departments;
	}
	
	public String getTitle() {
		return title;
	}
	
	public void setTitle(String title) {
		this.title = title;
	}
}
