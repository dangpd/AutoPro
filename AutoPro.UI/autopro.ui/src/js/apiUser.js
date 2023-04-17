import axios from "axios";

import base from "./baseService";
class UserService extends base {
    getAll() {
        let urlMain = `${this.getBaseService()}User`;
        return urlMain;
    }

    getUserById(id) {
        return `${this.getAll()}/${id}`;
    }

    register() {
        return `${this.getAll()}/`
    }

    login() {
        return `${this.getAll()}/login`
    }

}

const ApiUser = new UserService();
export default ApiUser;