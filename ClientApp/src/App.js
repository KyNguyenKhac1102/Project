import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import Admin from "./pages/Admin/Admin";
import DoituongPage from "./pages/Admin/Doituong/DoituongPage";
import HosoDetailPage from "./pages/Admin/Hoso/HosoDetailPage";
import HosoPage from "./pages/Admin/Hoso/HosoPage";
import NganhPage from "./pages/Admin/Nganh/NganhPage";
import TruongCreatePage from "./pages/Admin/Truong/TruongCreatePage";
import TruongEditPage from "./pages/Admin/Truong/TruongEditPage";
import TruongPage from "./pages/Admin/Truong/TruongPage";

import UserCreatePage from "./pages/Admin/User/UserCreatePage";
import UserEditPage from "./pages/Admin/User/UserEditPage";
import UserPage from "./pages/Admin/User/UserPage";

import Home from "./pages/Home/Home";
import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";

// const routes = [
//   {
//     path: "/",
//     exact: true,
//     sidebar: () => "",
//     main: () => <Home />,
//   },
//   {
//     path: "/login",
//     exact: false,
//     sidebar: () => "",
//     main: () => <Login />,
//   },
//   {
//     path: "/register",
//     exact: false,
//     sidebar: () => "",
//     main: () => <Register />,
//   },
//   {
//     path: "/admin",
//     exact: false,
//     sidebar: () => <Sidebar />,
//     main: () => <Admin />,
//   },
//   {
//     path: "/user",
//     exact: true,
//     sidebar: () => <Sidebar />,
//     main: () => <UserPage />,
//   },
//   {
//     path: "/user/edit/:id",
//     exact: true,
//     sidebar: () => <Sidebar />,
//     main: () => <UserEdit />,
//   },
//   {
//     path: "/hoso",
//     exact: true,
//     sidebar: () => <Sidebar />,
//     main: () => <HosoPage />,
//   },
//   {
//     path: "/truong",
//     exact: true,
//     sidebar: () => <Sidebar />,
//     main: () => <TruongPage />,
//   },
//   {
//     path: "/nganh",
//     exact: true,
//     sidebar: () => <Sidebar />,
//     main: () => <NganhPage />,
//   },
//   {
//     path: "/doituong",
//     exact: true,
//     sidebar: () => <Sidebar />,
//     main: () => <DoituongPage />,
//   },
// ];

export default function App() {
  return (
    <Router>
      <Route path="/login" component={Login} />
      <Route path="/register" component={Register} />

      <Route path="/" exact component={Home} />
      <Route path="/admin" component={Admin} />
      <Route path="/user" exact component={UserPage} />
      <Route path="/user/edit/:id" component={UserEditPage} />
      <Route path="/user/create" exact component={UserCreatePage} />

      <Route path="/truong" exact component={TruongPage} />
      <Route path="/truong/edit/:id" component={TruongEditPage} />
      <Route path="/truong/create" exact component={TruongCreatePage} />

      <Route path="/hoso" exact component={HosoPage} />
      <Route path="/hoso/detail/:id" component={HosoDetailPage} />

      <Route path="/nganh" component={NganhPage} />
      <Route path="/doituong" component={DoituongPage} />

      {/* <Switch>
        {routes.map((route, index) => (
          <Route
            key={index}
            path={route.path}
            exact={route.exact}
            children={route.main}
          />
        ))}
      </Switch>

      <Switch>
        {routes.map((route, index) => (
          <Route
            key={index}
            path={route.path}
            exact={route.exact}
            children={route.sidebar}
          />
        ))}
      </Switch> */}
    </Router>
  );
}
