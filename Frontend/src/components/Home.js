import React from 'react';
import { Link } from 'react-router-dom';
import { Home as HomeIcon, User, UserPlus, UserMinus, Edit } from 'lucide-react';

const Navbar = () => {
  return (
    <nav className="bg-gradient-to-r from-purple-500 to-indigo-600 p-4 rounded-lg shadow-md">
      <ul className="flex justify-around items-center">
        <NavItem to="/" icon={<HomeIcon />} text="Home" />
        <NavItem to="/get" icon={<User />} text="View Details" />
        <NavItem to="/post" icon={<UserPlus />} text="Add Entry" />
        <NavItem to="/delete" icon={<UserMinus />} text="Remove Entry" />
        <NavItem to="/update" icon={<Edit />} text="Edit Entry" />
      </ul>
    </nav>
  );
};

const NavItem = ({ to, icon, text }) => (
  <li>
    <Link to={to} className="flex flex-col items-center text-white hover:text-yellow-300 transition-colors duration-300">
      {icon}
      <span className="mt-1 text-sm">{text}</span>
    </Link>
  </li>
);

const Home = () => {
  return (
    <div className="min-h-screen bg-gradient-to-b from-gray-100 to-gray-200 p-8">
      <div className="max-w-4xl mx-auto bg-white rounded-xl shadow-2xl overflow-hidden">
        <header className="bg-indigo-700 text-white p-6">
          <h1 className="text-3xl font-bold text-center">Personal Details Management</h1>
        </header>
        <main className="p-6">
          <Navbar />
          <section className="mt-8 text-center">
            <p className="text-lg text-gray-700">
              Welcome to your personal information hub. Manage your details with ease and security.
            </p>
          </section>
        </main>
      </div>
    </div>
  );
};

export default Home;