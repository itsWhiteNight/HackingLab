package ma.emsi.roleuserjpa.service;

import ma.emsi.roleuserjpa.entities.Role;
import ma.emsi.roleuserjpa.entities.User;

public interface UserService {
    User addNewUser(User user);
    Role addNewRole(Role role);
    User findUserByUserName(String userName);
    Role findRoleByRoleName(String roleName);
    void addRoleToUser(String username,String rolename);
    User authentificate(String username,String password);


}
