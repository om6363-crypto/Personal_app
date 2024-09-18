import React from 'react';
import { Link } from 'react-router-dom';

const Navbar = () => {
    return (
        <nav>
            <ul>
                <li><Link to="/">Home</Link></li>
                <li><Link to="/get">Get Personal Details</Link></li>
                <li><Link to="/post">Post New Entry</Link></li>
                <li><Link to="/delete">Delete Entry</Link></li>
                <li><Link to="/update">Update Entry</Link></li>
            </ul>
        </nav>
    );
};

export default Navbar;
