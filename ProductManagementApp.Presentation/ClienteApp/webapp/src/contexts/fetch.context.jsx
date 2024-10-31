import { useState, createContext } from "react";

const FetchContext = createContext();

function FetchProvider(props) {
  const [data, setData] = useState([]);
  const [error, setError] = useState(null);
  const [message, setMessage] = useState("");

  const get = async (url) => {
    try {
      const response = await fetch(url, {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        },
      });
      if (!response.ok)
        throw new Error(`Error en la solicitud: ${response.status}`);
      const dataJson = await response.json();
      setData(dataJson);
      setMessage("Success!");
    } catch (error) {
      setError(true);
      setMessage(error.message);
      console.error(error.message);
    }
  };

  const post = async (url, bodyData, role) => {
    try {
      const response = await fetch(url, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          role: role,
        },
        body: JSON.stringify(bodyData),
      });
      if (!response.ok)
        throw new Error(`Error en la solicitud: ${response.status}`);
      const dataJson = await response.json();
      setData(dataJson);
      setMessage("Success!");
    } catch (error) {
      setError(true);
      setMessage(error.message);
      console.error(error.message);
    }
  };

  const put = async (url, updateData) => {
    try {
      const response = await fetch(url, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(updateData),
      });

      if (!response.ok)
        throw new Error(`Error en al solicutud: ${response.status}`);
      const dataJson = await response.json();
      setData(dataJson);
    } catch (error) {
      setError(true);
      setMessage(error.message);
    }
  };

  const remove = async (url) => {
    try {
      const response = await fetch(url, {
        method: "DELETE",
      });
      if (!response.ok)
        throw new Error(`Error en la solicitud: ${response.status}`);
    } catch (error) {
      setError(true);
      setMessage(error.message);
      console.error(error.message);
    }
  };

  return (
    <FetchContext.Provider
      value={{ data, error, message, get, post, put, remove }}
    >
      {props.children}
    </FetchContext.Provider>
  );
}

export { FetchContext, FetchProvider };
