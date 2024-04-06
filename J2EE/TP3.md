# Partie 1: Créer une application Web JEE avec Spring MVC, Thymeleaf et Spring Data JPA

## 1. Patient.java (Entity Class)

```java
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class Patient {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String name;
    private String email;
	
}
```

## 2. PatientRepository.java (Spring Data JPA Repository)
```java
import org.springframework.data.jpa.repository.JpaRepository;

public interface PatientRepository extends JpaRepository<Patient, Long> {
}
```

## 3. PatientController.java (Spring MVC Controller)
```java
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestParam;
import java.util.Optional;

@Controller
public class PatientController {

    @Autowired
    private PatientRepository patientRepository;

    // Display list of patients with pagination
    @GetMapping("/patients")
    public String viewHomePage(Model model, @RequestParam(defaultValue = "0") int page) {
        Page<Patient> patientPage = patientRepository.findAll(PageRequest.of(page, 5));
        model.addAttribute("patients", patientPage);
        model.addAttribute("currentPage", page);
        return "patients";
    }

    // Search patients
    @GetMapping("/patients/search")
    public String searchPatients(Model model, @RequestParam String keyword) {
        model.addAttribute("patients", patientRepository.findByNameContaining(keyword));
        model.addAttribute("keyword", keyword);
        return "patients";
    }

    // Delete patient
    @GetMapping("/patients/delete/{id}")
    public String deletePatient(@PathVariable Long id) {
        patientRepository.deleteById(id);
        return "redirect:/patients";
    }
}
```

## 4. patients.html (Thymeleaf Template for Displaying Patients)
```html
<!DOCTYPE html>
<html lang="en" xmlns:th="http://www.thymeleaf.org">
<head>
    <meta charset="UTF-8">
    <title>Patients</title>
</head>
<body>
    <h1>Patients List</h1>
    <table border="1">
        <thead>
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Email</th>
                <!-- Add other columns as needed -->
            </tr>
        </thead>
        <tbody>
            <tr th:each="patient : ${patients.content}">
                <td th:text="${patient.id}"></td>
                <td th:text="${patient.name}"></td>
                <td th:text="${patient.email}"></td>
                <!-- Add other columns as needed -->
                <td><a th:href="@{/patients/delete/{id}(id=${patient.id})}">Delete</a></td>
            </tr>
        </tbody>
    </table>

    <!-- Pagination -->
    <div>
        <a th:href="@{/patients?page=${currentPage - 1}}">Previous</a>
        <a th:href="@{/patients?page=${currentPage + 1}}">Next</a>
    </div>

    <!-- Search form -->
    <form action="/patients/search" method="get">
        <input type="text" name="keyword" placeholder="Search by name">
        <button type="submit">Search</button>
    </form>
</body>
</html>
```

# Partie 2: Créer une page template et valider les formulaires

## 1.patient-form.html (Thymeleaf Template for Patient Form)
```html
<!DOCTYPE html>
<html lang="en" xmlns:th="http://www.thymeleaf.org">
<head>
    <meta charset="UTF-8">
    <title>Add Patient</title>
</head>
<body>
    <h1>Add Patient</h1>
    <form action="/patients" method="post">
        <label for="name">Name:</label>
        <input type="text" id="name" name="name" required><br>
        <label for="email">Email:</label>
        <input type="email" id="email" name="email" required><br>
        <!-- Add other fields as needed -->
        <button type="submit">Add</button>
    </form>
</body>
</html>
```
## 2.PatientFormController.java (Spring MVC Controller for Handling Patient Form)
```java
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class PatientFormController {

    // Display form for adding patient
    @GetMapping("/patients/add")
    public String showPatientForm() {
        return "patient-form";
    }
}
```

# Partie 3: Sécurité avec Spring Security

## 1. SecurityConfig.java (Configuration for Spring Security)
```java
package ma.enset.hospitalapp.security;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.config.Customizer;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.provisioning.InMemoryUserDetailsManager;
import org.springframework.security.web.SecurityFilterChain;

@Configuration
@EnableWebSecurity
public class SecurityConfig {

    @Bean
    public InMemoryUserDetailsManager inMemoryUserDetailsManager(PasswordEncoder passwordEncoder) {
        String encodedPassword = passwordEncoder.encode("1234");
        System.out.println(encodedPassword);
        return new InMemoryUserDetailsManager(
                User.withUsername("user1").password(encodedPassword).roles("USER").build(),
                User.withUsername("user2").password(encodedPassword).roles("USER").build(),
                User.withUsername("admin").password(encodedPassword).roles("USER","ADMIN").build()
        );
    }

    @Bean
    public SecurityFilterChain securityFilterChain(HttpSecurity httpSecurity) throws Exception {
        return httpSecurity
                .formLogin(Customizer.withDefaults())
                .authorizeHttpRequests(ar->ar.requestMatchers("/deletePatient/**").hasRole("ADMIN"))
                .authorizeHttpRequests(ar->ar.requestMatchers("/admin/**").hasRole("ADMIN"))
                .authorizeHttpRequests(ar->ar.requestMatchers("/user/**").hasRole("USER"))
                .authorizeHttpRequests(ar->ar.anyRequest().authenticated())
                .build();
    }
}
```
