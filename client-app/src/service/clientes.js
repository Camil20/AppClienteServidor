import axios from "axios";

const getAll = function getAll() {
    return axios.get("https://localhost:44391/api/Clientes").then((res) => {
        return res.data;
    });
}

export default{
    getAll
}