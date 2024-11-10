import '../app-main/app-main.css';
import { Flex, Loader } from '@mantine/core';
import NoData from '../ui-components/no-data';
import TasksTable from '../ui-components/tasks-table';

const AppMain = ({tasks, loader, setLoader}) => {
    return (
        <div id='main' className='main'>
            <Flex
                style={{margin: '15px'}}>
                {tasks !== undefined ? tasks.length > 0 ? <TasksTable tasks={tasks} setLoader={setLoader}/> : <NoData /> : null}
            </Flex>
            <Flex
                style={{height: '50vh'}}
                justify={'center'}
                align={'center'}
                display={loader}>
                <Loader type={"oval"} size={100} />
            </Flex>   
        </div>
    );
};

export default AppMain;
