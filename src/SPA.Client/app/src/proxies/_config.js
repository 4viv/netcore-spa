import Axios from 'axios';
import IdentityProxy from './IdentityProxy';

// Axios default behavior
Axios.defaults.headers.common.Accept = 'application/json';

let url = null;

if (localStorage.getItem("config") !== null) {
    let config = JSON.parse(localStorage.getItem("config"));
    url = config.apiUrl;
}

// console.log(url);

export default {
    identityProxy: new IdentityProxy(Axios, url)
}