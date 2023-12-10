
import './App.css'
import { Routes, Route } from 'react-router-dom'
import IndexPage from './pages/IndexPage'
import LoginPage from './pages/LoginPage'
import Layout from './Layout'
import RegisterPage from './pages/RegisterPage'
import axios from 'axios'
import UserContextProvider from './UserContext'



import Account from './pages/AccountPage'
import AdminPage from './pages/admin/AdminPage'
import ProductAdminPage from './pages/admin/ProductAdminPage'
import HomeAdminPage from './pages/admin/HomeAdminPage'
import CustomerAdminPage from './pages/admin/CustomerAdminPage'
import ProductInfo from './pages/adminpages/ProductInfo'
import ProductUpdate from './pages/adminpages/ProductUpdate'
import ProductAdd from './pages/adminpages/ProductAdd'

import CustomerUpdate from './pages/adminpages/CustomerUpdate'

import { memoizedRefreshToken } from './common/refreshToken'
import CategoryAdminPage from './pages/admin/CategoryAdminPage'
import LibraryPage from './pages/admin/LibraryPage'
import LibraryProductsPageAdd from './pages/adminpages/LibraryProductsPageAdd'
import LibraryInfo from './pages/adminpages/LibraryInfo'
import BookStore from './pages/BookStore'
import ReservationPage from './pages/admin/ReservationPage'
import ReservationUpdate from './pages/adminpages/ReservationUpdate'
import Home from './Home'

axios.defaults.baseURL = 'http://localhost:4000/';
axios.defaults.withCredentials = true;

async function refreshAccessToken() {
  try {

    const token = await axios.get();
    console.log('refreshAccessToken');
    console.log(token)
    return token;

  } catch (err) {
    console.error(err);
    throw err;
  }
}

axios.interceptors.request.use(
  async function (config) {

    const urlTab = axios.getUri(config).split('/')
    const uri = urlTab[urlTab.length - 1]
    const arr = ['logout', 'login', 'register', 'profile', 'refresh'];

    console.log('verify role');

    if (!arr.includes(uri)) {
      const token = await memoizedRefreshToken()
      console.log('interceptore ' + token);
      if (token) {
        config.headers['Authorization'] = 'Bearer ' + token
      }
    }

    return config
  },
  function (error) {
    return Promise.reject(error);
  }
);


// axios.interceptors.response.use(
//   (response) => response,
//   (error) => {
//     const originalRequest = error.config;

//     if (error.response.status === 401 && !originalRequest._retry) {
//       originalRequest._retry = true;
//       return refreshAccessToken().then((data) => {
//         console.log('interceptors');
//         console.log(data);
//         originalRequest.headers.Authorization = `Bearer ${data}`;
//         return axios(originalRequest);
//       });
//     }

//     return Promise.reject(error);
//   }
// );


function App() {

  return (
    <UserContextProvider>
      <Routes>

        <Route path="" element={<Layout />}>
          {/* <Route path="/home" element={<Home />} /> */}
          {/* <Route index element={<Home />} /> */}
          <Route path="bookstore" element={<BookStore />} />

          <Route path="login" element={<LoginPage />} />
          <Route path="register" element={<RegisterPage />} />
          <Route path="account" element={<Account />} />
          <Route path="admin" element={<AdminPage />} >

            <Route path="product" element={<ProductAdminPage />} />
            <Route path="product/update/:id" element={<ProductUpdate />} />
            <Route path="product/info/:id" element={<ProductInfo />} />
            <Route path="product/add" element={<ProductAdd />} />

            <Route path="home" element={<HomeAdminPage />} />
            <Route path="category" element={<CategoryAdminPage />} />

            <Route path="customer" element={<CustomerAdminPage />} />
            <Route path="customer/update/:id" element={<CustomerUpdate />} />

            <Route path="library" element={<LibraryPage />} />
            <Route path="library/add/:id" element={<LibraryProductsPageAdd />} />
            <Route path="library/info/:id" element={<LibraryInfo />} />

            <Route path="reservation" element={<ReservationPage />} />
            <Route path="reservation/update/:id" element={<ReservationUpdate />} />

          </Route>
        </Route>
      </Routes>
    </UserContextProvider>
  )
}

export default App
