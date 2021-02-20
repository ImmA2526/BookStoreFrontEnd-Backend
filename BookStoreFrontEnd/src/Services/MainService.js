import axios from 'axios'

const baseUrl = "https://localhost:44387/api"

export default {

    post(requestUrl, data) {
        return axios({
            method: 'post',
            url: `${baseUrl}${requestUrl}`,
            data: data,
        })
    },

} //Export
