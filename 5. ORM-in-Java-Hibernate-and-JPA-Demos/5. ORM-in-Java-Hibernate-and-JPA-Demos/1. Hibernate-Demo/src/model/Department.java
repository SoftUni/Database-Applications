package model;

import java.util.HashSet;
import java.util.Set;

public class Department {
	private long deptId;
	private String name;
	private Set<Professor> professors = new HashSet<Professor>();
	private Set<Course> courses = new HashSet<Course>();

	public Set<Course> getCourses() {
		return courses;
	}
	
	public void setCourses(Set<Course> courses) {
		this.courses = courses;
	}
	
	public long getDeptId() {
		return deptId;
	}
	
	public void setDeptId(long deptId) {
		this.deptId = deptId;
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public Set<Professor> getProfessors() {
		return professors;
	}
	
	public void setProfessors(Set<Professor> professors) {
		this.professors = professors;
	}
}
