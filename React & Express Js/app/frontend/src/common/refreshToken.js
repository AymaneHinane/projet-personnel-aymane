import mem from "mem";

import axios from 'axios'

export const axiosInstance = axios.create({
  baseURL: 'http://localhost:4000/',
  withCredentials : true
});

const refreshTokenFn = async () => {
  console.log('here refreshToken');

 try {
    const {data} = await axiosInstance.get("/auth/refresh")
    const {accessToken} = data;
    console.log('refreshToken.js');
    console.log(accessToken);
      
    return accessToken;
   } catch (error) {
      console.log(error);
     alert("your session are expired  refeshToken.js")
  }
};

const maxAge = 10000;

export const memoizedRefreshToken = mem(refreshTokenFn, {
  maxAge,
});