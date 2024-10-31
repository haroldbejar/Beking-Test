import { useContext, useEffect } from "react";
import { FetchContext } from "../contexts/fetch.context";
import endPoints from "../endpoints/enpoints";

const ProductTable = ({ products, onEditProduct, onRemoveProduct }) => {
  const { data, get } = useContext(FetchContext);

  useEffect(() => {
    try {
      get(endPoints.product.list);
    } catch (err) {
      console.error(err);
    }
  }, []);

  return (
    <table className="min-w-full bg-white">
      <thead>
        <tr>
          <th className="py-2 px-4 border">Name</th>
          <th className="py-2 px-4 border">Price</th>
          <th className="py-2 px-4 border">Category</th>
          <th className="py-2 px-4 border">Actions</th>
        </tr>
      </thead>
      <tbody>
        {data.map((product, index) => (
          <tr key={index}>
            <td className="py-2 px-4 border">{product.name}</td>
            <td className="py-2 px-4 border">{product.price}</td>
            <td className="py-2 px-4 border">{product.category}</td>
            <td className="py-2 px-4 border">
              <button
                onClick={() => onEditProduct(product)}
                className="bg-yellow-500 text-white rounded px-2 py-1 mr-2"
              >
                Edit
              </button>
              <button
                onClick={() => onRemoveProduct(product)}
                className="bg-red-500 text-white rounded px-2 py-1"
              >
                Remove
              </button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default ProductTable;
