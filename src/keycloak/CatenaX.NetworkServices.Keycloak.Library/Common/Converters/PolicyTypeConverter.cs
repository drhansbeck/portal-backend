/********************************************************************************
 * Copyright (c) 2021,2022 Contributors to https://github.com/lvermeulen/Keycloak.Net.git and BMW Group AG
 * Copyright (c) 2021,2022 Contributors to the CatenaX (ng) GitHub Organisation.
 *
 * See the NOTICE file(s) distributed with this work for additional
 * information regarding copyright ownership.
 *
 * This program and the accompanying materials are made available under the
 * terms of the Apache License, Version 2.0 which is available at
 * https://www.apache.org/licenses/LICENSE-2.0.
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 *
 * SPDX-License-Identifier: Apache-2.0
 ********************************************************************************/

using CatenaX.NetworkServices.Keycloak.Library.Models.Clients;

namespace CatenaX.NetworkServices.Keycloak.Library.Common.Converters;

public class PolicyTypeConverter: JsonEnumConverter<PolicyType>
{
    private static readonly Dictionary<PolicyType, string> SPairs = new Dictionary<PolicyType, string>
    {
        [PolicyType.Role] = "role",
        [PolicyType.Client] = "client",
        [PolicyType.Time] = "time",
        [PolicyType.User] = "user",
        [PolicyType.Aggregate] = "aggregate",
        [PolicyType.Group] = "group",
        [PolicyType.Js] = "js"
    };

    protected override string EntityString { get; } = "type";

    protected override string ConvertToString(PolicyType value) => SPairs[value];

    protected override PolicyType ConvertFromString(string s)
    {
        if (SPairs.Values.Contains(s.ToLower()))
        {
            return SPairs.First(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase)).Key;
        }

        throw new ArgumentException($"Unknown {EntityString}: {s}");
    }
}
