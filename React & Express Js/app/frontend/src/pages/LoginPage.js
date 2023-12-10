import axios from 'axios';
import React from 'react'
import { useContext } from 'react';
import { useState } from 'react'
import { Link, Navigate } from 'react-router-dom'
import { UserContext } from '../UserContext';

export default function LoginPage() {

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [redirect, setRedirect] = useState(false);
    const [role,setRole] = useState()

    const { setUser,setConnect } = useContext(UserContext)

    async function handleLoginSubmit(ev) {
        ev.preventDefault();
       //console.log("here");
       try {
            const { data } = await axios.post('/auth/login', { email, password });
           console.log(data);
            setRole(data.roles[0])
            setConnect(true)
            setRedirect(true)
         } catch (err) {
            alert('login failed')
        }
    }

    if (redirect) {
        if(role == 'user')
         return <Navigate to={'/bookstore'} />
        else
         return <Navigate to={'/admin/home'} />
    }




    return (
        <div>
            
            <form onSubmit={handleLoginSubmit} style={{ marginTop: 60 }}>
                <div className='container' style={{ maxWidth: 500 }}>
                   <h1 className='mb-5'>Login</h1>
                    <div className="row mb-3" >
                        <label for="exampleInputEmail1" class="form-label">Email address</label>
                        <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"
                            placeholder='youremail.com' value={email}
                            onChange={e => setEmail(e.target.value)}
                        />
                        {/* <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div> */}
                    </div>
                    <div className="row mb-5" >
                        <label for="exampleInputPassword1" class="form-label">Password</label>
                        <input type="password" class="form-control" id="exampleInputPassword1"
                            placeholder='password' value={password}
                            onChange={e => setPassword(e.target.value)} />
                    </div>

                    <button type="submit" class="btn btn-primary mb-3">Login</button>
                    <div>
                        Don't have account yet?
                        <Link to={'/register'}> Register now</Link>
                    </div>
                </div>
            </form>
        </div>
    )
}
