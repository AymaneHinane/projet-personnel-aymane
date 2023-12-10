import React, { useContext,useState } from 'react'
import { Link,Outlet,NavLink } from 'react-router-dom';
import { UserContext } from '../../UserContext'

export default function AdminPage() {

    const { user } = useContext(UserContext)
    const {connect,Setconnect} = useState(user)


    return  (
        <div className="container-fluid vh-100 borders ">
            <div className="row vh-100 ">
                <div className="col-3" style={{paddingLeft:0}} >
                    <div className="d-flex flex-column flex-shrink-0 p-3 text-bg-dark vh-100" style={{ width: 280 }}>
                        <a href="/" className="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-white text-decoration-none">
                            <svg className="bi pe-none me-2" width="40" height="32"></svg>
                            <span className="fs-4">Administration</span>
                        </a>
                        <hr />
                        <ul className="nav nav-pills flex-column mb-auto">

                   
                           <li>
                                <NavLink to = {'/admin/home'} className={[({isActive}) => (isActive ? "active-style" : 'none'),'nav-link text-white'].join(' ')} >               
                                    <svg className="bi pe-none me-2" width="16" height="16"></svg>
                                    Home
                                </NavLink>
                            </li>
                    
                           
                            <li>
                                <NavLink to = {'/admin/category'} className={[({isActive}) => (isActive ? "active-style" : 'none'),'nav-link text-white'].join(' ')} >
                                    <svg className="bi pe-none me-2" width="16" height="16"></svg>
                                    category
                                </NavLink>
                            </li>
                            <li>
                                <NavLink to = {'/admin/product'} className={[({isActive}) => (isActive ? "active-style" : 'none'),'nav-link text-white'].join(' ')} >
                                    <svg className="bi pe-none me-2" width="16" height="16"></svg>
                                    Books
                                </NavLink>
                            </li>
                           
                            <li>
                                <NavLink to = {'/admin/customer'}className={[({isActive}) => (isActive ? "active-style" : 'none'),'nav-link text-white'].join(' ')} >
                                    <svg className="bi pe-none me-2" width="16" height="16"></svg>
                                    Customer
                                </NavLink>
                            </li>

                            <li>
                            <NavLink to = {'/admin/library'} className={[({isActive}) => (isActive ? "active-style" : 'none'),'nav-link text-white'].join(' ')} >
                                    <svg className="bi pe-none me-2" width="16" height="16"></svg>
                                    Library
                                </NavLink>
                            </li>

                            <li>
                            <NavLink to = {'/admin/reservation'} className={[({isActive}) => (isActive ? "active-style" : 'none'),'nav-link text-white'].join(' ')} >
                                    <svg className="bi pe-none me-2" width="16" height="16"></svg>
                                    Reservation
                                </NavLink>
                            </li>



                        </ul>


                    </div>
                </div>
                <div className="col-9 borders" style={{marginTop:50}}>
                    {/* <h1>content</h1> */}
                    <Outlet/>
                </div>
            </div>
        </div>
    )
}
