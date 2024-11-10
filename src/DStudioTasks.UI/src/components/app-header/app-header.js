import Informations from '../app-group-buttons/app-group-buttons';
import '../app-header/app-header.css';
import Header from '../ui-components/header-name';
import { Flex } from '@mantine/core';

const AppHeader = ({setTasks, setLoader, none, flex}) => {
    return (
        <Flex
            justify={'space-between'}
            className='header'>
            <Header />
            <Flex>                
                <Informations 
                    setTasks={setTasks}
                    setLoader={setLoader}
                    none={none}
                    flex={flex}/>
            </Flex>
        </Flex>
    )
};

export default AppHeader;
