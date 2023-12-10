import React, { useContext, useState,useEffect } from 'react'
import { Link, Navigate, Redirect } from 'react-router-dom'
import { UserContext } from './UserContext'
import axios from 'axios'


export default function Header() {

  const { user, setUser } = useContext(UserContext)
  const [redirect, setRedirect] = useState(false);

  const disconnected = async () => {
    try {
      await axios.get('/auth/logout');
      // alert('logout successful.');
      setRedirect(true)
      setUser(null);

    } catch (ex) {
      alert('logout failed.');
    }
  }


  useEffect(()=>{
      <Navigate to={'/home'} />
  },[redirect])

  // if (redirect) {
  //   console.log('here');
  //   return 

  // }

 // console.log(user);


  return (

    <header >

      <nav className="navbar navbar-expand-lg bg-success">
        <div className="container-fluid">


          <a className="navbar-brand  text-info" href="#">Book Store</a>
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav">

              {user != null && (
                <>
                  {user.roles.includes('admin', 'employee') ?

                    <li className="nav-item">
                      <Link to={'/admin'} className="nav-link active text-light" aria-current="page" href="#">admin</Link>
                    </li>
                    :
                    <li className="nav-item">
                      <Link to={'/bookstore'} className="nav-link active text-light" aria-current="page" href="#">Book Store</Link>
                    </li>
                  }
                </>


              )}

            </ul>
          </div>



          {user == null ? (
            <form className="d-flex" role="search">
              <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search" />

              <Link to={'/login'} >
                <button className="btn btn-outline-info me-2" type="submit">Login</button>
              </Link>
              <Link to={'/register'}>
                <button className="btn btn-outline-info me-2" type="submit">Register</button>
              </Link>
            </form>
          ) : (
            <div className="dropdown" style={{ marginRight: 30 }}>
              <button className="btn btn-outline-light dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" style={{ width: 30 }}>
                  <path strokeLinecap="round" strokeLinejoin="round" d="M17.982 18.725A7.488 7.488 0 0012 15.75a7.488 7.488 0 00-5.982 2.975m11.963 0a9 9 0 10-11.963 0m11.963 0A8.966 8.966 0 0112 21a8.966 8.966 0 01-5.982-2.275M15 9.75a3 3 0 11-6 0 3 3 0 016 0z" />
                </svg>

                {user.name} you are connected
              </button>
              <ul className="dropdown-menu" >
                <li><Link className="dropdown-item" to={'/account'}>Account Info</Link></li>
                <li><a className="dropdown-item" href="#">My Books</a></li>
                <li><hr className="dropdown-divider" /></li>
                <li><a className="dropdown-item" href="#" onClick={disconnected}>Disconnected</a></li>
              </ul>
            </div>
          )}

        </div>
      </nav>


      {/* to convert user to boolean */}
      {/* {!!user && (<p>{user.name}</p>)} */}

    </header>


  )
}
