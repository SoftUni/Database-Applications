package model;

import java.util.HashSet;
import java.util.Set;

public class Student extends Person {
	private String facultyNumber;
	private Set<Course> courses = new HashSet<Course>();

	public Set<Course> getCourses() {
		return courses;
	}
	
	public void setCourses(Set<Course> courses) {
		this.courses = courses;
	}
	
	public String getFacultyNumber() {
		return facultyNumber;
	}
	
	public void setFacultyNumber(String facultyNumber) {
		this.facultyNumber = facultyNumber;
	}
	
}
