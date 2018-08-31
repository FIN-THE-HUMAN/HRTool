import _ from 'lodash';
import DateUtils from 'utils/DateUtils';

import DutiesSource from '../sources/DutiesSource';
import RequirementsSource from '../sources/RequirementsSource';
import { Departures, EmploymentTypes, BranchOffices, VacancyStatuses } from '../constants/EnumsConstants';

export const defineSalaryString = (from, to) => {
  if (!from && !to) return 'Зарплата не указана';
  if (!from) return `до ${to} руб.`;
  if (!to) return `от ${from} руб.`;
  if (from === to) return `${from} руб.`;
  return `${from} - ${to} руб.`;
};

export const FormatStatusToServer = ({ status, ...rest }) => ({
  ...rest,
  status: _.findIndex(VacancyStatuses, { name: status })
});

export const FormatStatusToClient = ({ status, ...rest }) => ({
  ...rest,
  status: _.get(VacancyStatuses[status], 'name')
});

export const FormatVacancyToClient = (data) => {
  const reqs = _.partition(data.requirements, 'isAdditional');
console.log('data', data)
  return {
    ...data,
    ..._.omitBy({
      ...data,
      departureName: _.get(Departures[data.departureName], 'name'),
      employmentType: _.get(EmploymentTypes[data.employmentType], 'name'),
      status: _.get(VacancyStatuses[data.status], 'name'),
      branchOfficeCity: _.get(BranchOffices[data.branchOfficeCity], 'name'),
      requirements: reqs[0],
      additionalRequirements: reqs[1],
      creationDate: DateUtils.moment(data.creationDate)
    }, _.isUndefined)
  };
};

export const FormatVacancyToServer = ({
  departureName,
  employmentType,
  branchOfficeCity,
  status,
  requirements,
  additionalRequirements,
  ...rest
}) => ({
  ...rest,
  departureName: _.findIndex(Departures, { name: departureName }),
  employmentType: _.findIndex(EmploymentTypes, { name: employmentType }),
  status: _.findIndex(VacancyStatuses, { name: status }),
  branchOfficeCity: _.findIndex(BranchOffices, { name: branchOfficeCity }),
  requirements: _.concat(
    requirements || [],
    _.map(additionalRequirements, req => ({ ...req, isAdditional: true }))
  )
});

export const LoadDuties = search => DutiesSource
  .getDuties({ search })
  .then(({ response }) => response.map(({ id, name }) => ({ value: id, label: name })));

export const CreateDuty = name => DutiesSource.createDuty({ name });

export const LoadRequirements = search => RequirementsSource
  .getRequirements({ search })
  .then(({ response }) => response.map(({ id, name }) => ({ value: id, label: name })));

export const CreateRequirement = name => RequirementsSource.createRequirement({ name });
