import { Status } from "../../clients/task-client.ts";
import { Table } from "@mantine/core";
import { format } from "date-fns";

const TasksTable = ({tasks}) => {
    const statusMap = {
        0: Status.ToDo,
        1: Status.InProgress,
        2: Status.InReview,
        3: Status.Blocked,
        4: Status.Completed,
        5: Status.OnHold,
        6: Status.Canceled
    };

    const data = [];
    for (let i = 0; i < tasks.length; i++) {
        data.push([
            tasks[i].name, tasks[i].description, format(new Date(tasks[i].createdDate), 'do MMMM yyyy HH:mm:ss'),
            format(new Date(tasks[i].lastModifiedDate), 'do MMMM yyyy HH:mm:ss'), statusMap[tasks[i].status]
        ]);
    }
    const tasksTableData = {
        caption: 'Task Overview',
        head: ['Task Name', 'Task Description', 'Created Date', 'Last Modified Date', 'Task Status'],
        body: data,
    }

    return (<Table
            withColumnBorders
            striped 
            stripedColor={'#ebf1f7'}
            horizontalSpacing={'lg'} data={tasksTableData}/>)
}

export default TasksTable
