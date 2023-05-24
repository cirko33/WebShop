import api from "../api/api"


const register = async (data) => {
    try {
        await api.post("auth/register", data, { headers: { "Content-Type":"multipart/form-data" }});
    }
    catch(e) {
        alert(e.response.data.Exception);
        return Promise.reject(e);
    }
}

const getUser = async () => {
    try {
        const res = await api.get("profile");
        return res.data;
    }
    catch(e) {
        alert(e.response.data.Exception);
        return Promise.reject(e);
    }
}

const setUser = async (data) => {
    try {
        await api.put("profile", data, { headers: { "Content-Type":"multipart/form-data" }});
    }
    catch(e) {
        alert(e.response.data.Exception);
        return Promise.reject(e);
    }
}


export default {
    register,
    getUser,
    setUser,
}