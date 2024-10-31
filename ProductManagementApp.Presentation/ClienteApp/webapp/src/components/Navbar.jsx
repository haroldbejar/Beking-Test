import React, { useState } from "react";

const Navbar = ({ username, onLogout, onLogin }) => {
  const [showModal, setShowModal] = useState(false);
  const [userName, setUserName] = useState("");
  const [userRole, setUserRole] = useState("Admin");
  const [showLogin, setShowLogin] = useState(true);

  const handleLogin = () => {
    setShowModal(true);
  };

  const handleLogout = () => {
    setShowLogin(true);
    onLogout();
  };

  const handleModalClose = () => {
    setShowModal(false);
    setShowLogin(true);
  };

  const handleFormSubmit = (e) => {
    e.preventDefault();
    onLogin({ userName, userRole }); // Llamamos a la función `onLogin` con los valores actualizados
    setShowModal(false);
    setShowLogin(false);
  };

  return (
    <nav className="flex items-center justify-between bg-blue-600 p-4 text-white">
      {/* Brand Icon */}
      <div className="text-lg font-bold">
        <span>BrandIcon</span>
      </div>

      {/* User Info and Logout */}
      <div className="flex items-center space-x-4">
        <span>{username}</span>
        {showLogin && (
          <button
            onClick={handleLogin}
            className="bg-green-500 px-3 py-1 rounded hover:bg-green-600"
          >
            Login
          </button>
        )}

        <button
          onClick={handleLogout}
          className="bg-red-500 px-3 py-1 rounded hover:bg-red-600"
        >
          Logout
        </button>
      </div>

      {/*Modal*/}
      {showModal && (
        <div className="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50">
          <div className="bg-white p-6 rounded-lg shadow-lg w-80">
            <h2 className="text-lg font-bold mb-4">Login</h2>
            <form onSubmit={handleFormSubmit}>
              <div className="mb-4">
                <label className="block text-gray-700">User Name</label>
                <input
                  type="text"
                  value={userName}
                  onChange={(e) => setUserName(e.target.value)}
                  className=" text-black w-full p-2 border rounded"
                  required
                />
              </div>
              <div className="mb-4">
                <label className="block text-gray-700">User Role</label>
                <select
                  value={userRole}
                  onChange={(e) => setUserRole(e.target.value)}
                  className="text-black w-full p-2 border rounded"
                >
                  <option value="Admin">Admin</option>
                  <option value="Viewer">Viewer</option>
                </select>
              </div>
              <div className="flex justify-end space-x-4">
                <button
                  type="button"
                  onClick={handleModalClose}
                  className="px-4 py-2 bg-gray-300 rounded hover:bg-gray-400"
                >
                  Cancel
                </button>
                <button
                  type="submit"
                  className="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
                >
                  Login
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </nav>
  );
};

export default Navbar;
