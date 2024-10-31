import React, { useState, useContext } from "react";
import { FetchContext } from "../contexts/fetch.context";
import endPoints from "../endpoints/enpoints";

const ProductForm = ({ userRole }) => {
  // onAddProduct
  const { post } = useContext(FetchContext);
  const [productData, setProductData] = useState({
    name: "",
    price: 1,
    category: "",
  });

  if (userRole !== "Admin") {
    return null;
  }

  const handleChange = (e) => {
    const { name, value } = e.target;
    setProductData((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    try {
      post(endPoints.product.base, productData, userRole);
      console.log(productData);
      setProductData({ name: "", price: "", category: "" });
    } catch (err) {
      console.error(err);
    } finally {
      console.log("Product added successfully");
    }
  };

  return (
    <form
      onSubmit={handleSubmit}
      className="space-y-4 p-4 bg-gray-100 rounded-lg"
    >
      <div>
        <label className="block">Name</label>
        <input
          type="text"
          name="name"
          value={productData.name}
          onChange={handleChange}
          className="border rounded w-full p-2 text-center"
        />
      </div>
      <div>
        <label className="block">Price</label>
        <input
          type="number"
          min={1}
          name="price"
          value={productData.price}
          onChange={handleChange}
          className="border rounded w-full p-2 text-right"
        />
      </div>
      <div>
        <label className="block">Category</label>
        <input
          type="text"
          name="category"
          value={productData.category}
          onChange={handleChange}
          className="border rounded w-full p-2 text-center"
        />
      </div>
      <button type="submit" className="bg-blue-500 text-white rounded p-2 mt-4">
        Add Product
      </button>
    </form>
  );
};

export default ProductForm;
