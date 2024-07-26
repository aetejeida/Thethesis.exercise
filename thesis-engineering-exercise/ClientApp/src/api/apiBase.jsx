import axios from 'axios';

export default async function doRequest (options) {
    const config = {
        baseUrl: process.env.REACT_APP_API_URL,
        headers: { 'Content-Type' : 'application/json' },
        responseType: 'json',
        ...options,
    };
    
    return axios.request(config).then((response) => (response ? response.data : null));
}