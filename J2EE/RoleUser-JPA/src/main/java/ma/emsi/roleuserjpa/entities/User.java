package ma.emsi.roleuserjpa.entities;

import ch.qos.logback.core.joran.spi.NoAutoStart;
import com.fasterxml.jackson.annotation.JsonProperty;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;
@Entity
@Data
@NoArgsConstructor @AllArgsConstructor
@Table(name = "USERS")
public class User {
    @Id
    private String userId;
    @Column(name="USER_NAME",unique=true,length=20)
    private String username;
    @JsonProperty(access = JsonProperty.Access.WRITE_ONLY)
    private String password;
    @ManyToMany(mappedBy="users", fetch= FetchType.EAGER)
    private List<Role> roles;
}
