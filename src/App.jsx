import {
  Route,
  createBrowserRouter,
  createRoutesFromElements,
  RouterProvider,
} from "react-router-dom";
import React from "react";
import MainLayout from "./layouts/MainLayout";
import MainPage from "./pages/MainPage";
import JobsPage from "./pages/JobsPage";
import NotFound from "./pages/NotFound";
import JobDetailPage, { jobLoader } from "./pages/JobDetailPage";
import AddJob from "./pages/AddJob";
import EditJob from "./pages/EditJob";

const App = () => {
  const httpPOST = async (url, data) => {
    try {
      await fetch(url, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });
      return true;
    } catch (ex) {
      console.log("Error in http request: ", ex);
      return false;
    }
  };

  const httpPUT = async (url, data) => {
    try {
      await fetch(url, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });
      return true;
    } catch (ex) {
      console.log("Error in http request: ", ex);
      return false;
    }
  };

  const httpDelete = async (url) => {
    try {
      await fetch(url, {
        method: "DELETE",
      });
    } catch (ex) {
      console.log(ex);
    }
  };

  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<MainLayout />}>
        <Route index element={<MainPage />} />,
        <Route path="/jobs" element={<JobsPage />} />
        <Route path="/AddJob" element={<AddJob httpPost={httpPOST} />} />
        <Route
          path="/EditJob/:id"
          element={<EditJob httpPUT={httpPUT} />}
          loader={jobLoader}
        />
        <Route
          path="/jobs/:id"
          element={<JobDetailPage httpDelete={httpDelete} />}
          loader={jobLoader}
        />
        <Route path="*" element={<NotFound />} />
      </Route>
    )
  );

  return <RouterProvider router={router} />;
};

export default App;
