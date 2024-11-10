import { Flex, Group, Modal, Button, TextInput, Select, Text, Textarea, Dialog, rem } from "@mantine/core";
import { hasLength, useForm } from "@mantine/form";
import { useDisclosure } from "@mantine/hooks";
import { IconExclamationCircle, IconListDetails } from "@tabler/icons-react";
import { useState } from "react";
import { TaskClient, TaskDto, Status } from "../../clients/task-client.ts";

const Informations = ({setTasks, setLoader, none, flex}) => {
    const defaultMessage = 'An unexpected error occurred, please try again later.';
    const iconStyle = {width: rem(30), height: rem(30), color: '#e6f1ff'};
    const errorColorMessage  = '#ed455e';
    const successColorMessage = '#699bd1';
    const [successIcon, errorIcon] = [<IconListDetails style={iconStyle}/>, <IconExclamationCircle style={iconStyle}/>];
    const [icon, setIcon] = useState(successIcon);
    const [opened, { open, close }] = useDisclosure(false);
    const [popupOpened, setPopupOpened] = useState(false);
    const [popupColor, setPopupColor] = useState(successColorMessage);
    const [popupMessage, setPopupMessage] = useState(defaultMessage);
    const statuses = [Status.ToDo, Status.InProgress, Status.InReview, Status.Blocked, Status.Completed, Status.OnHold, Status.Canceled];
    const statusesMap = {
        [Status.ToDo]: 0,
        [Status.InProgress]: 1,
        [Status.InReview]: 2,
        [Status.Blocked]: 3,
        [Status.Completed]: 4,
        [Status.OnHold]: 5,
        [Status.Canceled]: 6
    };

    const task = useForm({
        mode:'uncontrolled',
        initialValues: {
            taskName: '',
            taskDescription: '',
            jobStatus: 0
        },
        validate: {
            taskName: (value) => value.trim().length > 0 ? null : 'enter task name',
            taskDescription: (value) => value.trim().length > 0 ? null : 'enter task description',
            jobStatus: hasLength({min: 0}, 'choose task status')
        }
    });

    const handleTasks = () => {
        setLoader(flex);
        const taskClient = new TaskClient();
        taskClient.getTasks()
            .then((response) => {
                setTasks([...response]);
                setLoader(none);
            })
            .catch((error) => {
                setPopupColor(errorColorMessage); 
                if (error.status !== undefined) {
                    setPopupMessage(error.message);
                }
                else {
                    setPopupMessage(defaultMessage);
                } 

                setTimeout(() => {
                    setPopupMessage(false);
                }, 1500);
                setLoader(none);
            });
    }

    return (
        <Group style={{marginRight: '35px'}}>
        <Modal
            title='Create Task'
            onClose={close}
            opened={opened}
            overlayProps={{
                backgroundOpacity: 0.55,
                blur: 3,
              }}>
            <Dialog 
                bg={popupColor}
                opened={popupOpened}
                size={'md'} 
                radius={'md'}
                position={{ top: 20, right: 20}}
                transitionProps={{transform: 0, duration: 200}}
                style={{border:'0.5px solid rgba(232, 237, 242, 0.3)'}}>
                <Flex
                    gap={'md'}
                    justify={'center'}>
                    {icon}
                    <Text
                        c={'#E8EDF2'} 
                        align='center'
                        size="sm" 
                        mb="xs" 
                        fw={500}>
                        {popupMessage}
                    </Text>
                </Flex>
            </Dialog>      
            <form onSubmit={task.onSubmit((newTask) => {
                const taskClient = new TaskClient(); 
                const request = TaskDto.fromJS({ 
                    name: newTask.taskName, 
                    description: newTask.taskDescription, 
                    status: statusesMap[newTask.jobStatus] });
                taskClient.create(request) 
                    .then(() => {
                        setIcon(successIcon);
                        setPopupMessage('New task was created successfully.');
                        setPopupOpened(true);
                        setPopupColor(successColorMessage);
                        setTimeout(() => {
                            setPopupOpened(false);
                        }, 1500); 
                    })
                    .catch((error) => {
                        setIcon(errorIcon);
                        setPopupColor(errorColorMessage); 
                        if (error.status !== undefined) {
                            setPopupMessage(error.message);
                        }
                        else {
                            setPopupMessage(defaultMessage);
                        } 

                        setTimeout(() => {
                            setPopupMessage(false);
                        }, 1500);
                    });
            })}>
                <Flex
                    gap={'md'}
                    direction={'column'}>
                    <TextInput 
                        withAsterisk
                        label='Task Name' 
                        placeholder='name'
                        defaultValue={task.key('taskName')}
                        {...task.getInputProps('taskName')}/>
                    <Textarea
                        withAsterisk
                        autosize
                        maxRows={5} 
                        label='Task Description' 
                        placeholder='description'
                        defaultValue={task.key('taskDescription')}
                        {...task.getInputProps('taskDescription')}/>
                    <Select
                        withAsterisk
                        clearable
                        label='Task Status'
                        placeholder='pick status'
                        data={statuses}
                        key={task.key('jobStatus')}
                        {...task.getInputProps('jobStatus')}/>
                    <Button type={'submit'}>Create</Button>    
                </Flex> 
            </form>   
        </Modal>
        <Button onClick={open}>Create Task</Button>
        <Button onClick={handleTasks}>Show Tasks</Button>        
    </Group>);
}

export default Informations;
