import api from "../api/api"

const login = async (creds) => {
    console.log(creds)
    const res = await api.post('auth/login', creds);

    if(res.data){
        console.log(res.data.token)
    }
}

export default {
    login
}