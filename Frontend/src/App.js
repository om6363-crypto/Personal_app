import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from './components/Home';
import GetPersonalDetails from './components/GetPersonalDetails';
import PostEntry from './components/PostEntry';
import DeleteEntry from './components/DeleteEntry';
import UpdateEntry from './components/UpdateEntry';

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/get" element={<GetPersonalDetails />} />
                <Route path="/post" element={<PostEntry />} />
                <Route path="/delete" element={<DeleteEntry />} />
                <Route path="/update" element={<UpdateEntry />} />
            </Routes>
        </Router>
    );
};

export default App;
