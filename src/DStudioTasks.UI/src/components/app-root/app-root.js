import AppFooter from "../app-footer/app-footer";
import AppMain from '../app-main/app-main';
import AppHeader from "../app-header/app-header";
import './app-root.css';
import { MantineProvider } from "@mantine/core";
import { useState } from "react";

const AppRoot = () => {
    const [tasks, setTasks] = useState(undefined);
    const [none, flex] = ['none', 'flex'];
    const [loader, setLoader] = useState(none);
    return (
      <MantineProvider>
        <div className="app-root">
          <AppHeader setTasks={setTasks} setLoader={setLoader} none={none} flex={flex}/>
          <AppMain 
            tasks={tasks} 
            loader={loader} 
            setLoader={setLoader}
            none={none}
            flex={flex}/>
          <AppFooter />
        </div>
      </MantineProvider>
    )
}

export default AppRoot;
