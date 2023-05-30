import api from '../api/api'

const getVerifiedUsers = async() => {
    try {
        const res = await api.get('admin/verified-users');
        return res.data;
    }
    catch(e) {
        alert(e.response.data.Exception);
        return [];
    }
}

const getWaitingUsers = async() => {
    try {
        const res = await api.get('admin/waiting-users');
        return res.data;
    }
    catch(e) {
        alert(e.response.data.Exception);
        return [];
    }
}

const getOrders = async() => {
    try {
        const res = await api.get('admin/orders');
        return res.data;
    }
    catch(e) {
        alert(e.response.data.Exception);
        return [];
    }
}

const postVerifyUser = async(data) => {
    try {
        await api.post('admin/verify-user', data);
    }
    catch(e) {
        alert(e.response.data.Exception);
    }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default {
    getVerifiedUsers,
    getWaitingUsers,
    getOrders,
    postVerifyUser
}