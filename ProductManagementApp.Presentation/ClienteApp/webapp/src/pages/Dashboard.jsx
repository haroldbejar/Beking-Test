import React, { useState } from "react";
import Navbar from "../components/Navbar";
import ProductForm from "../components/ProductForm";
import ProductTable from "../components/ProductTable";

const Dashboard = () => {
  const [products, setProducts] = useState([]);
  const [userData, setUserData] = useState({
    userName: "",
    userRole: "Viewer",
  });

  const addProduct = (product) => {
    setProducts((prev) => [...prev, product]);
  };

  const editProduct = (product) => {
    const updatedProducts = products.map((p) =>
      p.name === product.name ? product : p
    );
    setProducts(updatedProducts);
  };

  const removeProduct = (product) => {
    setProducts(products.filter((p) => p.name !== product.name));
  };

  const handleLogin = ({ userName, userRole }) => {
    setUserData({
      userName,
      userRole,
    });
  };

  const handleLogout = () => {
    setUserData({ userName: "", userRole: "Viewer" });
  };

  return (
    <div>
      <Navbar
        username={userData.userName}
        onLogout={handleLogout}
        onLogin={handleLogin}
      />
      <div className="p-6 space-y-6">
        <h1 className="text-2xl font-bold">Dashboard</h1>
        <ProductForm onAddProduct={addProduct} userRole={userData.userRole} />
        <ProductTable
          products={products}
          onEditProduct={editProduct}
          onRemoveProduct={removeProduct}
        />
      </div>
    </div>
  );
};

export default Dashboard;
