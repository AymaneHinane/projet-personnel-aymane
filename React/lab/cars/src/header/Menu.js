import React from 'react'
import './header.css'
import {Link,NavLink} from 'react-router-dom'


function Menu() {
    return (
        <nav>
            <ul>
                <li><Link to="/" >Docs</Link></li>
                <li><Link to="/forum" >forum</Link></li>
                <li><NavLink to="/tutorials" >Tutorials</NavLink></li>
            </ul>
        </nav>
    )
}

export default Menu
