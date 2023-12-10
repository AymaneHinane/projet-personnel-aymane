import React from 'react'
import { useState } from 'react'
import { Link } from 'react-router-dom'
import axios from "axios"

export default function RegisterPage() {

    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [phone,setPhone] = useState('');
    const [roles,setRole] = useState(['user'])

    async function registerUser(e) {
        e.preventDefault();
        try {
            await axios.post('/auth/register', {
                name,
                email,
                password,
                phone,
                roles
            })
            alert('Registration successful. Now you can log in');
        } catch (ex) {
            alert('Registartion failed! Please try again later')
        }
    }

    return (

        <div>

            <form onSubmit={registerUser} style={{ marginTop: 60 }}>
                <div className='container' style={{ maxWidth: 500 }}>
                    <h1 className='mb-5'>Register</h1>

                    <div className="row mb-3" >
                        <label for="exampleInputEmail1" class="form-label">user name</label>
                        <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"
                            placeholder='full name' value={name}
                            onChange={e => setName(e.target.value)}/>
                    </div>

                    <div className="row mb-3" >
                        <label for="exampleInputEmail1" class="form-label">Email address</label>
                        <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"
                            placeholder='youremail.com' value={email}
                            onChange={e => setEmail(e.target.value)}/>
                    </div>

                    <div className="row mb-3" >
                        <label for="exampleInputPassword1" class="form-label">Phone</label>
                        <input type="text" class="form-control" id="exampleInputPassword1"
                            placeholder='phone' value={phone}
                            onChange={e => setPhone(e.target.value)} />
                    </div>

                    <div className="row mb-5" >
                        <label for="exampleInputPassword1" class="form-label">Password</label>
                        <input type="password" class="form-control" id="exampleInputPassword1"
                            placeholder='password' value={password}
                            onChange={e => setPassword(e.target.value)} />
                    </div>





                    <button type="submit" class="btn btn-primary mb-3">Register</button>
                    <div>
                        Already a member?
                        <Link to={'/register'}> Login now</Link>
                    </div>
                </div>
            </form>
        </div>
    )
}
