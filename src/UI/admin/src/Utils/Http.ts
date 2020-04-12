import axios from 'axios';
import { message } from 'antd';

axios.defaults.timeout = 50000;
axios.defaults.baseURL = 'http://localhost:60857/api';

axios.interceptors.request.use(
  config => {
    if (localStorage.getItem('access_token')) {
      config.headers['Authorization'] = `Bearer ${localStorage.getItem('access_token')}`;
    }
    return config;
  },
  error => {
    return Promise.reject(error);
  }
);

axios.interceptors.response.use(
  response => {
    return response;
  },
  error => {
    if (!error.response) {
      message.error('请求超时');
      return Promise.reject(error.response);
    }

    switch (error.response.status) {
      case 401:
        alert(401);
        break;
      case 400:
        message.error(error.response.data.message);
        break;
      case 500:
        message.error('服务器出错');
        break;
      default:
    }

    return Promise.reject(error.response);
  }
);

export default axios;