function solution() {
//     Extend the Person and Teacher from the previous task and add a
//     class Student inheriting from Person. Add toString() functions to all classes, the formats should be as follows:
// • Person - returns "Person (name: {name}, email: {email})"
//     • Student - returns "Student (name: {name}, email: {email}, course: {course})"
//     • Teacher - returns "Teacher (name: {name}, email:{email}, subject:{subject})"
//     Try to reuse code by using the toString() function of the base class.

    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }

        toString() {
            return `${this.constructor.name} (name: ${this.name}, email: ${this.email})`
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString() {
            let newString = super.toString();
            newString = newString.substr(0, newString.length - 1);

            return newString + `, subject: ${this.subject})`;
        }
    }

    class Student extends Person {

        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString() {
            let newString = super.toString();
            newString = newString.substr(0, newString.length - 1);

            return newString + `, course: ${this.course})`;
        }

    }


    return {
        Person,
        Teacher,
        Student
    }

}
